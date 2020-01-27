import {
    get,
    post,
    put,
    del
} from './requester.js';

(() => {
    const templatesPaths = {
        header: './templates/common/header.hbs',
        footer: './templates/common/footer.hbs',
        loginForm: './templates/login/loginForm.hbs',
        team: './templates/catalog/team.hbs',
        registerForm: './templates/register/registerForm.hbs',
        createForm: './templates/create/createForm.hbs',
        teamMember: './templates/catalog/teamMember.hbs',
        teamControls: './templates/catalog/teamControls.hbs',
        editForm: './templates/edit/editForm.hbs'
    }
    const app = Sammy('#main', function () {
        this.use('Handlebars', 'hbs');

        this.get('index.html', function (ctx) {
            loadPage(ctx, './templates/home/home.hbs');
        });
        this.get('#/', function (ctx) {
            loadPage(ctx, './templates/home/home.hbs');
        });
        this.get('#/home', function (ctx) {
            loadPage(ctx, './templates/home/home.hbs');
        });
        this.get('#/about', function (ctx) {
            loadPage(ctx, './templates/about/about.hbs');
        });
        this.get('#/login', function (ctx) {
            loadPage(ctx, './templates/login/loginPage.hbs');
        });
        this.get('#/register', function (ctx) {
            loadPage(ctx, './templates/register/registerPage.hbs');
        });
        this.get('#/create', function (ctx) {
            loadPage(ctx, './templates/create/createPage.hbs');
        });
        this.get('#/edit/:id', function (ctx) {
            loadPage(ctx, './templates/edit/editPage.hbs');
        });

        this.post('#/login', function (ctx) {
            const {
                username,
                password
            } = ctx.params;
            postRequests(ctx, ['user', 'login', 'Basic', {
                username,
                password
            }], '#/home');
        });
        this.post('#/create', function (ctx) {
            const {
                name,
                comment
            } = ctx.params;
            const members = []
            postRequests(ctx, ['appdata', 'teams', 'Kinvey', {
                name,
                comment,
                members
            }], '#/catalog');
        });
        this.post('#/register', function (ctx) {
            const {
                username,
                password,
                repeatPassword
            } = ctx.params;
            if (username.length >= 3 && password.length >= 3 && password === repeatPassword) {
                postRequests(ctx, ['user', '', 'Basic', {
                    username,
                    password
                }], '#/home')
            } else {
                alert('Invalid input parameters!');
            }
        });
        this.get('#/logout', function (ctx) {
            sessionStorage.clear();
            ctx.redirect('#/home');
        });
        this.get('#/catalog', function (ctx) {
            getRequests(ctx, ['appdata', 'teams', 'Kinvey'], loadCatalogPage);
        });
        this.get('#/catalog/:id', function (ctx) {
            const id = ctx.params.id;
            getRequests(ctx, ['appdata', `teams/${id}`, 'Kinvey'], loadTeamPage);
        });
        this.get('#/leave/:id', function (ctx) {
            const id = ctx.params.id;
            getRequests(ctx, ['appdata', `teams/${id}`, 'Kinvey'], leaveTeam, id);
        });
        this.get('#/join/:id', function (ctx) {
            const id = ctx.params.id;
            getRequests(ctx, ['appdata', `teams/${id}`, 'Kinvey'], joinTeam, id);
        });
        this.post('#/edit', function (ctx) {
            const id = ctx.app.last_location[1].split('/').pop();
            getRequests(ctx, ['appdata', `teams/${id}`, 'Kinvey'], updateTeamInfo, id);
        });
    });

    function saveUserInfo(res) {
        if (res.username && res._kmd.authtoken) {
            sessionStorage.setItem('username', res['username']);
            sessionStorage.setItem('authtoken', res._kmd['authtoken']);
            sessionStorage.setItem('id', res._id);
        }
    }

    function getUserInfo(ctx) {
        ctx.loggedIn = sessionStorage.getItem('authtoken');
        ctx.username = sessionStorage.getItem('username');
        ctx.userID = sessionStorage.getItem('id');
    }

    function loadPage(ctx, path) {
        getUserInfo(ctx);
        ctx.loadPartials(templatesPaths)
            .then(function () {
                this.partial(path);
            });
    }

    function postRequests(ctx, params, path) {
        post(...params)
            .then(res => saveUserInfo(res))
            .then(res => ctx.redirect(path))
            .catch(console.error)
    }

    function getRequests(ctx, params, fn, id) {
        get(...params)
            .then(data => fn(ctx, data, id))
            .catch(console.error)
    }

    function putRequest(ctx, params, path) {
        put(...params)
            .then(res => ctx.redirect(path))
            .catch(console.error)
    }

    function loadCatalogPage(ctx, data) {
        ctx.teams = data;
        loadPage(ctx, './templates/catalog/teamCatalog.hbs');
    }

    function loadTeamPage(ctx, data) {
        getUserInfo(ctx);
        ctx.name = data.name;
        ctx.comment = data.comment;
        ctx.members = data.members;
        ctx.isAuthor = data._acl.creator === ctx.userID;
        ctx.teamId = data._id;
        ctx.isOnTeam = data.members.find(obj => obj.username === ctx.username);
        loadPage(ctx, './templates/catalog/details.hbs');
    }

    function joinTeam(ctx, data, id) {
        const newUser = {
            username: sessionStorage.username
        };
        data.members.push(newUser);
        putRequest(ctx, ['appdata', `teams/${id}`, 'Kinvey', data], `#/catalog/${id}`);
    }

    function leaveTeam(ctx, data, id) {
        const index = data.members.findIndex(obj => obj.username === sessionStorage.username);
        data.members.splice(index, 1);
        putRequest(ctx, ['appdata', `teams/${id}`, 'Kinvey', data], `#/catalog/${id}`);
    }

    function updateTeamInfo(ctx, data, id) {
        const {
            name,
            comment
        } = ctx.params;
        data.name = name;
        data.comment = comment;
        putRequest(ctx, ['appdata', `teams/${id}`, 'Kinvey', data], '#/catalog');
    }
    app.run();
})()
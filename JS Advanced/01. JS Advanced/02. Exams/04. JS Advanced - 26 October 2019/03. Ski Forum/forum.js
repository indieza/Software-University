class Forum {
    constructor() {
        this._users = [];
        this._questions = [];
        this._id = 1;
    }

    register(username, password, repeatPassword, email) {
        if (!username || !password || !repeatPassword || !email) {
            throw new Error("Input can not be empty");
        }

        if (password !== repeatPassword) {
            throw new Error("Passwords do not match");
        }

        if (this._users.find(u => u.username === username) || this._users.find(u => u.email === email)) {
            throw new Error("This user already exists!");
        }

        const user = {
            username: username,
            password: password,
            email: email,
            repeatPassword: repeatPassword,
            isLoggedIn: false
        };

        this._users.push(user);
        return `${username} with ${email} was registered successfully!`;
    }

    login(username, password) {
        const user = this._users.find(u => u.username === username);

        if (!user) {
            throw new Error("There is no such user");
        }

        if (user.password === password && user.isLoggedIn === false) {
            user.isLoggedIn = true;
            return "Hello! You have logged in successfully";
        }
    }

    logout(username, password) {
        const user = this._users.find(u => u.username === username);

        if (!user) {
            throw new Error("There is no such user");
        }

        if (user.password === password && user.isLoggedIn === true) {
            user.isLoggedIn = false;
            return "You have logged out successfully";
        }
    }

    postQuestion(username, question) {
        const user = this._users.find(u => u.username === username);

        if (!user || user.isLoggedIn === false) {
            throw new Error("You should be logged in to post questions");
        }

        if (!question) {
            throw new Error("Invalid question");
        }

        const targetQuestion = {
            id: this._id++,
            username: username,
            question: question,
            answers: []
        };

        this._questions.push(targetQuestion);
        return "Your question has been posted successfully";
    }

    postAnswer(username, questionId, answer) {
        const user = this._users.find(u => u.username === username);

        if (!user || user.isLoggedIn === false) {
            throw new Error("You should be logged in to post answers");
        }

        if (!answer) {
            throw new Error("Invalid answer");
        }

        const question = this._questions.find(q => q.id === questionId);

        if (!question) {
            throw new Error("There is no such question");
        }

        question.answers.push({
            username: username,
            answer: answer
        });

        return "Your answer has been posted successfully";
    }

    showQuestions() {
        let result = "";

        for (const question of this._questions) {
            result += `Question ${question.id} by ${question.username}: ${question.question}\n`;

            for (const answer of question.answers) {
                result += `---${answer.username}: ${answer.answer}\n`;
            }
        }

        return result.trim();
    }
}

let forum = new Forum();

forum.register('Michael', '123', '123', 'michael@abv.bg');
forum.register('Stoyan', '123ab7', '123ab7', 'some@gmail@.com');
forum.login('Michael', '123');
forum.login('Stoyan', '123ab7');

forum.postQuestion('Michael', "Can I rent a snowboard from your shop?");
forum.postAnswer('Stoyan', 1, "Yes, I have rented one last year.");
forum.postQuestion('Stoyan', "How long are supposed to be the ski for my daughter?");
forum.postAnswer('Michael', 2, "How old is she?");
forum.postAnswer('Michael', 2, "Tell us how tall she is.");

console.log(forum.showQuestions());
console.log("-----------------------------------------------");

let forum1 = new Forum();

forum1.register('Jonny', '12345', '12345', 'jonny@abv.bg');
forum1.register('Peter', '123ab7', '123ab7', 'peter@gmail@.com');
forum1.login('Jonny', '12345');
forum1.login('Peter', '123ab7');

forum1.postQuestion('Jonny', "Do I need glasses for skiing?");
forum1.postAnswer('Peter', 1, "Yes, I have rented one last year.");
forum1.postAnswer('Jonny', 1, "What was your budget");
forum1.postAnswer('Peter', 1, "$50");
forum1.postAnswer('Jonny', 1, "Thank you :)");

console.log(forum1.showQuestions());
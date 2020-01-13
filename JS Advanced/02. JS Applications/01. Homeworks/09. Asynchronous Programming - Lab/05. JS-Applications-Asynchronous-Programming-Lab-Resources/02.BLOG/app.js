const baseUrl = `https://blog-apps-c12bf.firebaseio.com/posts`;
const postsData = document.getElementById("posts");

function attachEvents() {
    function loadPosts() {
        fetch(`${baseUrl}.json`)
            .then(parseData())
            .then(data => {
                Object.entries(data)
                    .forEach(([value, element]) => {
                        const option = document.createElement("option");
                        option.value = value;
                        option.id = element.id;
                        option.innerHTML = element.title;
                        postsData.appendChild(option);
                    });
            })
            .catch(printError())
    }


    function viewPost() {
        const postId = postsData.value;

        fetch(`${baseUrl}/${postId}`)
            .then(parseData())
            .then(data => {

            })
            .catch(printError());
    }

    function parseData() {
        return resources => {
            if (!resources.ok) {
                throw new Error(JSON.stringify({
                    status: resources.status,
                    statusText: resources.statusText
                }));
            }
            return resources.json();
        };
    }

    function printError() {
        return (errorData) => {
            console.log(errorData.message);
        };
    }

    return {
        loadPosts,
        viewPost
    };
}

const result = attachEvents();
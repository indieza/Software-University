class Article {
    constructor(title, creator) {
        this.title = title;
        this.creator = creator;
        this._comments = [];
        this._likes = [];
        this._commentsCount = 1;
    }

    get likes() {
        if (this._likes.length === 0) {
            return `${this.title} has 0 likes`;
        } else if (this._likes.length === 1) {
            return `${this._likes[0].username} likes this article!`
        } else {
            return `${this._likes[0].username} and ${this._likes.length - 1} others like this article!`;
        }
    }

    like(username) {
        if (this._likes.find(x => x.username === username)) {
            throw new Error("You can't like the same article twice!");
        }

        if (username === this.creator) {
            throw new Error("You can't like your own articles!");
        }

        this._likes.push({
            username: username
        });

        return `${username} liked ${this.title}!`;
    }

    dislike(username) {
        const like = this._likes.find(x => x.username === username);
        if (!like) {
            throw new Error("You can't dislike this article!");
        }

        const index = this._likes.findIndex(x => x.username === username);
        this._likes.splice(index, 1);
        return `${username} disliked ${this.title}`;
    }

    comment(username, content, id) {
        if (id === undefined || !this._comments.find(x => x.Id === id)) {
            this._comments.push({
                Id: this._commentsCount++,
                Content: content,
                Username: username,
                Replies: []
            });

            return `${username} commented on ${this.title}`;
        }

        if (this._comments.find(x => x.Id === id)) {
            this._comments.find(x => x.Id === id).Replies.push({
                Id: `${id}.${this._comments.find(x => x.Id === id).Replies.length + 1}`,
                Content: content,
                Username: username
            });

            return "You replied successfully";
        }
    }

    toString(sortingType) {
        let result = `Title: ${this.title}\nCreator: ${this.creator}\nLikes: ${this._likes.length}\nComments:\n`;

        if (sortingType === "asc") {

            for (const comment of this._comments.sort((a, b) => a.Id - b.Id)) {
                result += `-- ${comment.Id}. ${comment.Username}: ${comment.Content}\n`;

                for (const reply of comment.Replies.sort((a, b) => a.Id - b.Id)) {
                    result += `--- ${reply.Id}. ${reply.Username}: ${reply.Content}\n`;
                }
            }
        }

        if (sortingType === "desc") {
            for (const comment of this._comments.sort((a, b) => b.Id - a.Id)) {
                result += `-- ${comment.Id}. ${comment.Username}: ${comment.Content}\n`;

                for (const reply of comment.Replies.sort((a, b) => b.Id - a.Id)) {
                    result += `--- ${reply.Id}. ${reply.Username}: ${reply.Content}\n`;
                }
            }
        }

        if (sortingType === "username") {
            for (const comment of this._comments.sort((a, b) => a.Username.localeCompare(b.Username))) {
                result += `-- ${comment.Id}. ${comment.Username}: ${comment.Content}\n`;

                for (const reply of comment.Replies.sort((a, b) => a.Username.localeCompare(b.Username))) {
                    result += `--- ${reply.Id}. ${reply.Username}: ${reply.Content}\n`;
                }
            }
        }

        return result.trim();
    }
}
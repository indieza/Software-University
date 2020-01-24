(function () {
    let commands = {
        upvote: (object) => object['upvotes'] += 1,
        downvote: (object) => object['downvotes'] += 1,
        score: (object) => {
            "use strict";
            let upVotes = object['upvotes'];
            let downVotes = object['downvotes'];
            let result = [];
            let obfuscationNumber = 0;
            let maxVotes;

            if ((upVotes + downVotes) > 50) {
                maxVotes = Math.max(upVotes, downVotes);
                obfuscationNumber = Math.ceil(0.25 * maxVotes);
            }

            result.push(upVotes + obfuscationNumber);
            result.push(downVotes + obfuscationNumber);
            result.push(upVotes - downVotes);
            let rating = getRating(object);
            result.push(rating);

            return result;
        },
        call: (object, args) => {
            return commands[args](object);
        }
    };
    return commands;

    function getRating(object) {
        let upVotes = object['upvotes'];
        let downVotes = object['downvotes'];
        let totalVotes = upVotes + downVotes;
        let balance = upVotes - downVotes;

        if (totalVotes < 10) {
            return 'new';
        }

        if ((upVotes / totalVotes) > 0.66) {
            return 'hot';
        }

        if ((downVotes / totalVotes <= 0.66) && balance >= 0 && (upVotes > 100 || downVotes > 100)) {
            return 'controversial';
        }

        if (balance < 0 && totalVotes >= 10) {
            return 'unpopular';
        }

        return 'new';
    }
})();
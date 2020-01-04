(function () {
    return {
        add: (v1, v2) => [v1[0] + v2[0], v1[1] + v2[1]],
        multiply: (v1, num) => [v1[0] * num, v1[1] * num],
        length: (v1) => Math.sqrt(v1[0] * v1[0] + v1[1] * v1[1]),
        dot: (v1, v2) => v1[0] * v2[0] + v1[1] * v2[1],
        cross: (v1, v2) => v1[0] * v2[1] - v1[1] * v2[0]
    }
})();
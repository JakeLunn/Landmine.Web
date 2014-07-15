(function () {
    var onGameOver = function () {
        console.log(arguments);
        alert("thanks for playing");
    };

    $(function () {
        var game = window.Landmine.start({
            canvas: document.getElementById("landmine"),
            gameOver: onGameOver
        });

        game.on("gameOver", onGameOver);
    });
})();
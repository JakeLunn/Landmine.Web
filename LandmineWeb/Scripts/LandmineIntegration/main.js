(function () {
    var onGameOver = function () {
        alert("thanks for playing");
    };

    $(function () {
        window.Landmine.start({
            canvas: document.getElementById("landmine"),
            gameOver: onGameOver
        });
    });
})();
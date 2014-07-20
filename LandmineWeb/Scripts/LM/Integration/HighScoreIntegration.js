/// <reference path="../../knockout.d.ts" />
var LM;
(function (LM) {
    (function (Integration) {
        var game;

        function startGame() {
            game = window.Landmine.start({
                canvas: document.getElementById("landmine")
            });

            game.on("game:over", onGameOver);
        }
        Integration.startGame = startGame;

        function onGameOver(score) {
            console.log(score);

            var dialog = LM.Integration.HighScoreDialog.show({
                Nickname: "",
                Value: score.score,
                Level: score.level
            });
        }
    })(LM.Integration || (LM.Integration = {}));
    var Integration = LM.Integration;
})(LM || (LM = {}));

LM.Integration.startGame();
//# sourceMappingURL=HighScoreIntegration.js.map

/// <reference path="../../knockout.d.ts" />
var LM;
(function (LM) {
    var Integration;
    (function (Integration) {
        var game; //Landmine game
        function startGame() {
            game = window.Landmine.start({
                canvas: document.getElementById("landmine"),
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
    })(Integration = LM.Integration || (LM.Integration = {}));
})(LM || (LM = {}));
LM.Integration.startGame();
//# sourceMappingURL=HighScoreIntegration.js.map
/// <reference path="../../knockout.d.ts" />
var LM;
(function (LM) {
    (function (Integration) {
        var game;

        function startGame() {
            window.Landmine.start({
                canvas: document.getElementById("landmine")
            });
        }
        Integration.startGame = startGame;
    })(LM.Integration || (LM.Integration = {}));
    var Integration = LM.Integration;
})(LM || (LM = {}));

LM.Integration.startGame();

var score = {
    Value: Math.floor(Math.random() * 1000),
    Level: 3,
    Nickname: ""
};

var dialog = new LM.Integration.HighScoreDialog(score);
dialog.show();
//# sourceMappingURL=HighScoreIntegration.js.map

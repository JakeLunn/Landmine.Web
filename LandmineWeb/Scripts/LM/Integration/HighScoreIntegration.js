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

LM.Scores.highest().then(function (scores) {
    var model = new LM.Binding.HighScoreList(scores);
    var score = {
        Value: Math.floor(Math.random() * 1000),
        Level: 3,
        Nickname: ""
    };

    var yourscore = new LM.Binding.HighScore(score, true);
    model.scores.push(yourscore);
    ko.applyBindings(model, $('.modal')[0]);

    LM.Modal.show({
        success: function () {
            LM.Scores.save(yourscore.toScore());
        }
    });
}).fail(function (error) {
    console.log(error);
});
//# sourceMappingURL=HighScoreIntegration.js.map

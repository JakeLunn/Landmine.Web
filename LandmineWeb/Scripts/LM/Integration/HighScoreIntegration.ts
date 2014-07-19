/// <reference path="../../knockout.d.ts" />
module LM {

    export module Integration {

        var game: any; //Landmine game

        export function startGame() {
            (<any>window).Landmine.start({
                canvas: document.getElementById("landmine")
            });
        }


    }
}

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
        success: () => {
            LM.Scores.save(yourscore.toScore());
        }
    });

}).fail((error) => { console.log(error); });
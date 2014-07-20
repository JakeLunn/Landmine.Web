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

var score = {
    Value: Math.floor(Math.random() * 1000),
    Level: 3,
    Nickname: ""
};

var dialog = new LM.Integration.HighScoreDialog(score);
dialog.show();
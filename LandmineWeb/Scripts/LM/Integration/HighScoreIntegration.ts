/// <reference path="../../knockout.d.ts" />
module LM {

    interface GameOverParams {
        score: number;
        level: number;
    }

    export module Integration {

        var game: any; //Landmine game

        export function startGame() {
            game = (<any>window).Landmine.start({
                canvas: document.getElementById("landmine"),
            });

            game.on("game:over", onGameOver);
        }

        function onGameOver(score : GameOverParams) {
            console.log(score);

            var dialog = LM.Integration.HighScoreDialog.show({
                Nickname: "",
                Value: score.score,
                Level: score.level
            });
        }
    }
}

LM.Integration.startGame();



module LM {
    export module Integration {
        export module HighScoreDialog {

            var userScore: LM.Binding.HighScore;
            var viewModel: LM.Binding.HighScoreList;

            function setUp() {
                userScore = new LM.Binding.HighScore({
                    Nickname: '',
                    Value: 0,
                    Level: 1
                }, true);

                viewModel = new LM.Binding.HighScoreList([]);
                viewModel.scores.push(userScore);

                ko.applyBindings(viewModel, $('.modal')[0]);
            }

            function resetUserScore(score: Score): void {
                userScore.Level(score.Level);
                userScore.Nickname(score.Nickname);
                userScore.Value(score.Value);
            }

            function resetViewModel(): void {
                while (viewModel.scores().length > 0) {
                    viewModel.scores.pop();
                }
                viewModel.scores.push(userScore);
                viewModel.loading(true);
            }

            export function show(score: Score): void {
                debugger;
                resetUserScore(score);
                resetViewModel();

                LM.Modal.show({
                    success: () => {
                        if (userScore.Nickname() !== "") {
                            LM.Scores.save(userScore.toScore());
                        }
                    },
                    closed: () => {

                    }
                });

                load();
            }

            function load(): void {
                LM.Scores.highest().then((scores) => {
                    scores.forEach((score) => {
                        viewModel.scores.push(
                            new Binding.HighScore(score, false));
                    });

                    viewModel.loading(false);
                });
            }

            setUp();
        }
    }
} 
module LM {
    export module Integration {
        export class HighScoreDialog {

            private userScore: LM.Binding.HighScore;
            private viewModel: LM.Binding.HighScoreList;

            constructor(score: Score) {
                this.userScore = new LM.Binding.HighScore(score, true);
                this.viewModel = new LM.Binding.HighScoreList([]);
                this.viewModel.scores.push(this.userScore);

                ko.applyBindings(this.viewModel, $('.modal')[0]);
            }

            public show(): void {
                LM.Modal.show({
                    success: () => {
                        if (this.userScore.Nickname() !== "") {
                            LM.Scores.save(this.userScore.toScore());
                        }
                    }
                });

                this.load();
            }

            private load(): void {
                LM.Scores.highest().then((scores) => {
                    scores.forEach((score) => {
                        this.viewModel.scores.push(
                            new Binding.HighScore(score, false));
                    });

                    this.viewModel.loading(false);
                });
            }
        }
    }
} 
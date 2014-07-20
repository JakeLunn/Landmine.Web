var LM;
(function (LM) {
    (function (Integration) {
        (function (HighScoreDialog) {
            var userScore;
            var viewModel;

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

            function resetUserScore(score) {
                userScore.Level(score.Level);
                userScore.Nickname(score.Nickname);
                userScore.Value(score.Value);
            }

            function resetViewModel() {
                while (viewModel.scores().length > 0) {
                    viewModel.scores.pop();
                }
                viewModel.scores.push(userScore);
                viewModel.loading(true);
            }

            function show(score) {
                resetUserScore(score);
                resetViewModel();

                LM.Modal.show({
                    success: function () {
                        if (userScore.Nickname() !== "") {
                            LM.Scores.save(userScore.toScore());
                        }
                    },
                    closed: function () {
                    }
                });

                load();
            }
            HighScoreDialog.show = show;

            function load() {
                LM.Scores.highest().then(function (scores) {
                    scores.forEach(function (score) {
                        viewModel.scores.push(new LM.Binding.HighScore(score, false));
                    });

                    viewModel.loading(false);
                });
            }

            setUp();
        })(Integration.HighScoreDialog || (Integration.HighScoreDialog = {}));
        var HighScoreDialog = Integration.HighScoreDialog;
    })(LM.Integration || (LM.Integration = {}));
    var Integration = LM.Integration;
})(LM || (LM = {}));
//# sourceMappingURL=HighScoreDialog.js.map

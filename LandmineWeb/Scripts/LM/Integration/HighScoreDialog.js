var LM;
(function (LM) {
    (function (Integration) {
        var HighScoreDialog = (function () {
            function HighScoreDialog(score) {
                this.userScore = new LM.Binding.HighScore(score, true);
                this.viewModel = new LM.Binding.HighScoreList([]);
                this.viewModel.scores.push(this.userScore);

                ko.applyBindings(this.viewModel, $('.modal')[0]);
            }
            HighScoreDialog.prototype.show = function () {
                var _this = this;
                LM.Modal.show({
                    success: function () {
                        if (_this.userScore.Nickname() !== "") {
                            LM.Scores.save(_this.userScore.toScore());
                        }
                    }
                });

                this.load();
            };

            HighScoreDialog.prototype.load = function () {
                var _this = this;
                LM.Scores.highest().then(function (scores) {
                    scores.forEach(function (score) {
                        _this.viewModel.scores.push(new LM.Binding.HighScore(score, false));
                    });

                    _this.viewModel.loading(false);
                });
            };
            return HighScoreDialog;
        })();
        Integration.HighScoreDialog = HighScoreDialog;
    })(LM.Integration || (LM.Integration = {}));
    var Integration = LM.Integration;
})(LM || (LM = {}));
//# sourceMappingURL=HighScoreDialog.js.map

/// <reference path="../../knockout.d.ts" />
/// <reference path="HighScore.ts" />
var HighScore = LM.Binding.HighScore;
var LM;
(function (LM) {
    (function (Binding) {
        var HighScoreList = (function () {
            function HighScoreList(scores) {
                var _this = this;
                this.scores = ko.observableArray(scores.map(function (s) {
                    return new Binding.HighScore(s, false);
                }));

                this.sortedScores = ko.computed(function () {
                    return _this.scores().sort(function (left, right) {
                        return right.Value() - left.Value();
                    });
                });
            }
            return HighScoreList;
        })();
        Binding.HighScoreList = HighScoreList;
    })(LM.Binding || (LM.Binding = {}));
    var Binding = LM.Binding;
})(LM || (LM = {}));
//# sourceMappingURL=HighScoreList.js.map

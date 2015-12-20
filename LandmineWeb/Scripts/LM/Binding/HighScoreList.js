/// <reference path="../../knockout.d.ts" />
/// <reference path="HighScore.ts" />
var LM;
(function (LM) {
    var Binding;
    (function (Binding) {
        var HighScoreList = (function () {
            function HighScoreList(scores) {
                var _this = this;
                this.scores = ko.observableArray(scores.map(function (s) { return new Binding.HighScore(s, false); }));
                this.sortedScores = ko.computed(function () {
                    return _this.scores().sort(function (left, right) {
                        return right.Value() - left.Value();
                    });
                });
                this.loading = ko.observable(true);
            }
            return HighScoreList;
        })();
        Binding.HighScoreList = HighScoreList;
    })(Binding = LM.Binding || (LM.Binding = {}));
})(LM || (LM = {}));
//# sourceMappingURL=HighScoreList.js.map
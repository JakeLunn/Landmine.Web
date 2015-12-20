var LM;
(function (LM) {
    var Binding;
    (function (Binding) {
        var HighScore = (function () {
            function HighScore(score, isEditable) {
                this.Value = ko.observable(score.Value);
                this.Level = ko.observable(score.Level);
                this.Nickname = ko.observable(score.Nickname);
                this.IsEditable = ko.observable(isEditable);
            }
            HighScore.prototype.toScore = function () {
                return {
                    Value: this.Value(),
                    Level: this.Level(),
                    Nickname: this.Nickname()
                };
            };
            return HighScore;
        })();
        Binding.HighScore = HighScore;
    })(Binding = LM.Binding || (LM.Binding = {}));
})(LM || (LM = {}));
//# sourceMappingURL=HighScore.js.map
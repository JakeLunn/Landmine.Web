/// <reference path="../q.d.ts" />
'use strict';
var LM;
(function (LM) {
    var Scores;
    (function (Scores) {
        function save(score) {
            var deferred = Q.defer();
            $.post("/api/score", score)
                .then(function (data) {
                deferred.resolve(true);
            }).fail(function (error) {
                deferred.reject(error);
            });
            return deferred.promise;
        }
        Scores.save = save;
        function highest() {
            var deferred = Q.defer();
            $.getJSON('/api/scores/high').then(function (data) {
                deferred.resolve(data);
            })
                .fail(function (error) {
                deferred.reject(error);
            });
            return deferred.promise;
        }
        Scores.highest = highest;
    })(Scores = LM.Scores || (LM.Scores = {}));
})(LM || (LM = {}));
//# sourceMappingURL=LM.Score.js.map
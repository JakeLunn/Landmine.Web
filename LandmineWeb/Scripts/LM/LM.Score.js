/// <reference path="../q.d.ts" />
'use strict';
var LM;
(function (LM) {
    (function (Scores) {
        function save(score) {
            var deferred = Q.defer();

            $.post("/api/score", score).then(function (data) {
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
            }).fail(function (error) {
                deferred.reject(error);
            });

            return deferred.promise;
        }
        Scores.highest = highest;
    })(LM.Scores || (LM.Scores = {}));
    var Scores = LM.Scores;
})(LM || (LM = {}));
//var Scores = {};
//Scores.save = function (score) {
//    var deferred = Q.defer();
//    $.post('/api/score', score).then(function() {
//        deferred.resolve();
//    }).error(function (err) {
//        deferred.reject(err);
//    });
//    return deferred.promise;
//};
//Score.highest = function () {
//    var deferred = Q.defer();
//    $.getJSON("/api/scores/high").then(function (scores) {
//        deferred.resolve(scores);
//    });
//};
//LM.Scores = Scores;
//# sourceMappingURL=LM.Score.js.map

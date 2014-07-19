(function () {
    var LM = window.LM || (window.LM = {});

    var Scores = {};

    Scores.save = function (score) {
        var deferred = Q.defer();
        $.post('/api/score', score).then(function() {
            deferred.resolve();
        }).error(function (err) {
            deferred.reject(err);
        });

        return deferred.promise;
    };

    Score.highest = function () {
        var deferred = Q.defer();

        $.getJSON("/api/scores/high").then(function (scores) {
            deferred.resolve(scores);
        });
    };


    LM.Scores = Scores;
})();
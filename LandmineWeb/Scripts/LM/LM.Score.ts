/// <reference path="../q.d.ts" />
'use strict';
module LM {
    export interface Score {
        Nickname: string;
        Value: number;
        Level: number;
    }

    export module Scores {
        export function save(score: Score) {
            var deferred = Q.defer();

            $.post("/api/score", score)
            .then((data) => {
                deferred.resolve(true);
            }).fail((error) => {
                deferred.reject(error);
            });

            return deferred.promise;
        }

        export function highest(): Q.Promise<Score[]> {
            var deferred = Q.defer<Score[]>();

            $.getJSON('/api/scores/high').then((data) => {
                deferred.resolve(data);
            })
            .fail((error) => {
                deferred.reject(error);
            });

            return deferred.promise;
        }
    }
}

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
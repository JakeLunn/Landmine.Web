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
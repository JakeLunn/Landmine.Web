module LM {
    export module Binding {
        export class HighScore {
            public Value: KnockoutObservable<number>;
            public Level: KnockoutObservable<number>;
            public Nickname: KnockoutObservable<string>;
            public IsEditable: KnockoutObservable<boolean>;

            constructor(score: Score, isEditable: boolean) {
                this.Value = ko.observable(score.Value);
                this.Level = ko.observable(score.Level);
                this.Nickname = ko.observable(score.Nickname);
                this.IsEditable = ko.observable(isEditable);
            }

            public toScore(): Score {
                return {
                    Value: this.Value(),
                    Level: this.Level(),
                    Nickname: this.Nickname()
                };
            }
        }
    }
} 
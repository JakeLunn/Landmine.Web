(function () {
    
    

    var onGameOver = function (data) {

        var score = data.score;

        var modalAccepted = function ($modal) {
            $form = $modal.find('form');

            var obj = {
                Nickname: $modal.find('input').val(),
                Score: score,
                Level: 1
            };

            $.post('/api/score', obj).success(function () {
                alert('saved!');
            }).error(function () {
                console.log(arguments);
                alert('error!');
            });
        };
        

        var options = {
            title: 'Your Score: ' + score,
            success: modalAccepted
        };

        var $modal = LM.Modal.show(options);

        $.getJSON('/api/scores/high').success(function (data) {

            var html = "<ul>";
            data.forEach(function (score) {
                html = html + "<li><span class='score'>" + score.Value + "</span><span class='player'>" + score.Nickname + "</span></li>"
            });
            html += "</ul>";

            $modal.find('#high-scores').html(html);
        });
    };

    $(function () {
        var game = window.Landmine.start({
            canvas: document.getElementById("landmine")
        });

        game.on("gameOver", onGameOver);
    });
})();
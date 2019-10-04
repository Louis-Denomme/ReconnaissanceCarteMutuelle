function setImage(input) {
    if (input.files && input.files[0]) {
        for (var i = 0; i < input.files.length; ++i) {

            //var reader = new FileReader();
            $('.dropdown-divider').after('<img src="'+URL.createObjectURL(event.target.files[i])+'" id="preview'+i+'" alt="mutuelle" class="img-thumbnail preview"><a id="remove" class="remove" onclick="remove(this);">X</a>');
            
            //var img = $("#preview" + i);

            //reader.onload = function (e) {
                //img.attr('src', e.target.result);
                //console.log(e.target.result);
            //}

            //reader.readAsDataURL(input.files[0]);

            $("#labelDownloadCard").css('display', 'none');
            $("button").fadeIn();
        }
    }
}

function remove(el) {
    $('#downloadCard').val("");
    $(el).prev($('img')).fadeOut();
    $(el).prev($('img')).remove();
    $(el).fadeOut();
    $(el).remove();

    if (!$('.preview').length) {
        $('.card').remove();
        $('button').css('display', 'none');
        $("#labelDownloadCard").fadeIn();
    }
}

function sendCard() {
    var formData = new FormData($("form")[0]);
    console.log(formData);
    
    $.ajax({
        type: "POST",
        data: formData,
        url: "api/Match",
        success: function (msg) {
            alert(msg)
        },
        cache: false,
        contentType: false,
        processData: false
    });

    getMutuelles();
};

function getMutuelles() {
    $.ajax({
        type: "GET",
        url: "api/Mutuelle",
        cache: false,
        success: function (data) {
            $("#form").after('<div id="response" class="container d-flex justify-content-center flex-row flex-wrap"></div>');
            $.each(data, function (key, mutuelle) {
                $("#response").append('<div class="card" style="width: 18rem; display: none;">' +
                    '<img src="Images/Logos/actil.png" class="card-img-top" alt="logo">' +
                    '<div class="card-body">' +
                    '<h5 class="card-title">' + mutuelle.name + '</h5>' +
                    '<p class="card-text">90%</p>' +
                    '</div>' +
                    '</div>');
            });
            $('.card').each(function () {
                $(this).fadeIn();
            })
        }
    });
}
$(document).ready(function () {
    $(function () {
        var maxLength = 250;
        $(".show-read-more").each(function () {
            var myStr = $(this).text();
            if ($.trim(myStr).length > maxLength) {
                var newStr = myStr.substring(0, maxLength);
                var removedStr = myStr.substring(maxLength, $.trim(myStr).length);
                $(this).empty().html(newStr);
                $(this).append(' <a href="javascript:void(0);" class="read-more">read more...</a>');
                $(this).append('<span class="more-text">' + removedStr + '</span>');
            }
        });
        $(".read-more").click(function () {
            $(this).siblings(".more-text").contents().unwrap();
            $(this).remove();
        });
        var numItems = $('.panel-success').length - 1
        $('#resultCount').text(numItems + " university returned")
        addMoreLinkBehaviour();
        addMoreCommentsBehaviour();


        var connection = $.hubConnection();
        var hub = connection.createHubProxy("pageHitsCounter");

        hub.on("OnRecordHit", function (hitCount, registedUsers) {
            $('#pageHitCount').text(hitCount + " Active User - " + registedUsers + " Registered User");
        });
        connection.start(function ()
        {
            hub.invoke("RecordHit");
        });


        $("#searchDegree").click(function () {
            SearchByDegree();
        });

        $("#searchCat").click(function () {
            SearchByCat();
        });

        $('#langSelect').change(function () {
            $(this).parents("form").submit();
        });
    });

    var doc = document.getElementById("googleMap");
    //getLocation();
    showPosition(15.609365, 32.541711);

    function addMoreLinkBehaviour() {
        $(document).on('click', '.itemlink', function (e) {
            $(this).html("<img src='/images/ajax-loader.gif' />");
            e.preventDefault();
            $.get($(this).attr("href"), function (response) {
                $('#moreLink').remove();
                $('#resultLstID').append(response);
                var numItems = $('.panel-success').length - 1
                $('#resultCount').text(numItems + " university returned")
            });
            return false;
        });
    }

    function addMoreCommentsBehaviour() {
        $(document).on('click', '.moreComment', function (e) {
            $(this).html("<img src='/images/ajax-loader.gif' />");
            e.preventDefault();
            $.get($(this).attr("href"), function (response) {
                $('#moreComment').remove();
                $('#resultLstID').append(response);
            });
            return false;
        });
    }
})

function getLocation() {
    if (navigator.geolocation) {
        navigator.geolocation.getCurrentPosition(showPosition, showError);
    }
}

function showPosition(latitude, longitude) {
    var latlon = latitude + "," + longitude; //position.coords.latitude + "," + position.coords.longitude;

    var img_url = "http://maps.googleapis.com/maps/api/staticmap?center="
    + latlon + "&zoom=14&size=400x300&sensor=false";
    var coords = new google.maps.LatLng(latitude, longitude);

    //var mapOptions = {
    //    zoom: 15,
    //    center: coords,
    //    mapTypeControl: true,
    //    mapTypeId: google.maps.MapTypeId.ROADMAP
    //}


    $("#googleMap").innerHTML = "<img src='" + img_url + "'>";
}

function showError(error) {
    switch (error.code) {
        case error.PERMISSION_DENIED:
            doc.innerHTML = "Request for Geolocation denied by the user."
            break;
        case error.POSITION_UNAVAILABLE:
            doc.innerHTML = "Unavailable location information."
            break;
        case error.TIMEOUT:
            doc.innerHTML = "Location request timed out."
            break;
        case error.UNKNOWN_ERROR:
            doc.innerHTML = "UNKNOWN_ERROR."
            break;
    }
}
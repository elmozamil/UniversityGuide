function SearchByDegree()
{
    var degree = $("#degreelst").val();
    var city = $("#citylst").val();
    var admision = $("#admissionlst").val();

    document.location.href = "../programs/SearchProgramsByDegree?degree=" + degree + "&adType=" + admision + "&city=" + city;
}


function SearchByCat() {
    var category = $("#catlst").val();
    var year = $("#yearslst").val();
    var dicipline = $("#diplst").val();

    document.location.href = "../programs/SearchProgramsByCat?decipline=" + dicipline + "&period=" + year;
}
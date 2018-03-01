  window.onload = function () {

            setInterval(function () { take_snapshot() }, 3000);
        }
        function take_snapshot() {
            // take snapshot and get image data
            Webcam.snap(function (data_uri) {
                // display results in page
                document.getElementById('results').innerHTML =
                    '<h2>Here is your image:</h2>' +
                    '<img id="base64image" src="' + data_uri + '"/>';
            });



            var file = document.getElementById("base64image").src;

            var formdata = new FormData();
            formdata.append("base64image", file);

            $.ajax({
                url: "/home/SaveImage",
                type: "POST",
                data: formdata,
                processData: false,
                contentType: false



            });

        }
var searchLetter = document.querySelector('#searchLetter').innerHTML;
var countLettersDiv = document.querySelector('#countLetters');

document.querySelectorAll('.div-table-col')
    .forEach(e => e.addEventListener("click", function () {
        console.log("click");
        if (searchLetter == e.innerHTML) {
            e.style.background = "green";
            countLettersDiv.innerHTML = countLettersDiv.innerHTML - 1;

            if (countLettersDiv.innerHTML == 0) {
                clearInterval(timer);

                document.querySelector('.endGame').style.display = 'block';
            }
        }
        else {
            e.style.background = "red";
        }
    }
    ))

var sec = 0;
function pad(val) { return val > 9 ? val : "0" + val; }
var timer = setInterval(function () {
    $("#seconds").html(pad(++sec % 60));
    $("#minutes").html(pad(parseInt(sec / 60, 10)));
}, 1000);
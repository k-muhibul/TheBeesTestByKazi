// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

$(document).ready(function () {
    $('.sidepanel-tile').hover(function (e) {
        console.log("SidePanel")
        var imgID = `#img-${e.currentTarget.id.split('-')[1]}`;
        $(imgID).css('border', '1.5px red solid')
        $(imgID).css('border-color', 'red')
        $(this).css('background-color', 'whitesmoke');
    }, function (e) {
        $(this).css('background-color', '#ddd');
        var imgID = `#img-${e.currentTarget.id.split('-')[1]}`;
        $(imgID).css('border-color', 'transparent')
    });
});



const container = document.querySelector('.image-container');
const images = document.querySelectorAll('.image-container img:not(#beeHive)');
const speed = 2;

function damageBees() {
    $.ajax({
        url: "/damage",
        method: 'GET',
        success: function (data) {
            var bees = JSON.parse(data);
            var deadCount = 0;
            console.log(bees.length)
            for (var i = 0; i < bees.length; i++) {
                if (bees[i].Dead == true) {
                    deadCount++;
                }
             
            }
           
            bees.forEach(bee => {
                var id = `img-${bee.reference}`;
                var imageElm = document.getElementById(id);
                imageElm.setAttribute('data-dead', bee.Dead);
                var sideID = `details-${bee.reference}`;
                $(`#${sideID}`).children().each(function (index, element) {
                    
                    if (index == 0 && imageElm.getAttribute('data-dead') == "true") { $(element).css('border', '3px red solid') }
                    if (index == 1) {
                        element.childNodes[3].innerHTML = `Health: ${bee.Health}`
                        element.childNodes[5].innerHTML = ` ${bee.Dead==true ? "Dead" : "Alive"}`
                    }
                });

            })
         
        },
        error: function (xhr, textStatus, errorThrown) {
            console.log(errorThrown);
        }
    });

}


function animateImages() {
    const images = document.querySelectorAll('.image-container img:not(#beeHive)');
    images.forEach(img => {

        if (img.getAttribute('data-dead') == "true") {
            const randomX = Math.floor(Math.random() * (container.offsetWidth - img.offsetWidth));
            const randomY = 650;
            img.position = {
                x: randomX,
                y: randomY
            };
        }
  
        if (!img.position) {
            if (img.getAttribute('data-dead') == "true") {
                const randomX = Math.floor(Math.random() * (container.offsetWidth - img.offsetWidth));
                const randomY = 650;
                img.position = {
                    x: randomX,
                    y: randomY
                };
            }
            else {
                const randomX = Math.floor(Math.random() * (container.offsetWidth - img.offsetWidth));
                const randomY = Math.floor(Math.random() * (container.offsetHeight - img.offsetHeight));
                img.position = {
                    x: randomX,
                    y: randomY
                };
                img.direction = getRandomDirection();
            }
        }


        if (!img.isHovered) {
            if (img.getAttribute('data-dead') == "true") {
                if (img.getAttribute('data-dead-set') != "true") {
                    const randomX = Math.floor(Math.random() * (container.offsetWidth - img.offsetWidth));
                    img.style.transform = `translate(${randomX}px, 620px)`
                    img.setAttribute('data-dead-set', "true");
                }

            }
            else {
                img.position.x += img.direction.x * speed;
                img.position.y += img.direction.y * speed;
                img.style.transform = `translate(${img.position.x}px, ${img.position.y}px)`;
            }

            if (img.position.x <= 0 || img.position.x >= container.offsetWidth - img.offsetWidth) {
                img.direction.x *= -1;
            }
            if (img.position.y <= 0 || img.position.y >= container.offsetHeight - img.offsetHeight) {
                img.direction.y *= -1;
            }
        }
    });
    requestAnimationFrame(animateImages);
}

function getRandomDirection() {
    const randomAngle = Math.random() * Math.PI * 2;
    return {
        x: Math.cos(randomAngle),
        y: Math.sin(randomAngle)
    };
}
images.forEach(img => {
    img.addEventListener('mouseenter', () => {
        img.isHovered = true;
    });
    img.addEventListener('mouseleave', () => {
        img.isHovered = false;
    });
    img.addEventListener('click', () => {
        const name = img.getAttribute('data-name');
        alert(name);
    });
});
function restart() {
    window.location="/restart"
}
function loadBees(e) {
   
}
animateImages();
function HomePageControl(controlDiv, map) {

            // Set CSS for the control border.
            var controlUI = document.createElement('div');
            controlUI.style.backgroundColor = '#fff';
            controlUI.style.border = '2px solid #fff';
            controlUI.style.borderRadius = '3px';
            controlUI.style.boxShadow = '0 2px 6px rgba(0,0,0,.3)';
            controlUI.style.cursor = 'pointer';
            controlUI.style.marginBottom = '22px';
            controlUI.style.textAlign = 'center';
            controlUI.style.float =  'left';
            controlUI.title = 'Click to Go Back to HomePage';
            controlDiv.appendChild(controlUI);

            // Set CSS for the control interior.
            var controlText = document.createElement('div');
            controlText.style.color = 'rgb(25,25,25)';
            controlText.style.fontFamily = 'Roboto,Arial,sans-serif';
            controlText.style.fontSize = '15px';
            controlText.style.lineHeight = '25px';
            controlText.style.paddingLeft = '5px';
            controlText.style.paddingRight = '5px';
            controlText.innerHTML = 'Home Page';
            controlUI.appendChild(controlText);

            // Setup the click event listeners: simply set the map to Main Center.
            controlUI.addEventListener('click', function() {
                window.location.href = 'http://teamjager.tk/';
            });

        }
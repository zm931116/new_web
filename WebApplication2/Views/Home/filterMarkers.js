        function filterMarkers(category) {
            for (i = 0; i < gmarkers1.length; i++) {
                marker = gmarkers1[i];
                clusMarkers = []
                // If is same category or category not picked
                if (marker.category == category || category.length === 0) {
                    marker.setVisible(true);
                    clusMarkers.push(marker);
                }
                // Categories don't match 
                else {
                    marker.setVisible(false);
                }
            }
        }
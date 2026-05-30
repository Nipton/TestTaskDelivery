let lastQuery = '';
function initializeCitySelect(selector, apiUrl) {
    new TomSelect(selector, {
        load: function (query, callback) {
            lastQuery = query;
            if (!query || query.length < 2) {
                callback();
                return;
            }
            fetch(`${apiUrl}?term=${encodeURIComponent(query)}`)
                .then(response => {
                    if (!response.ok) return callback();
                    return response.json();
                })
                .then(data => {
                    var results = data.map(city => ({
                        value: city.id,
                        text: city.name
                    }));
                    callback(results);
                }).catch(() => callback());
        },
        create: false,
        maxOptions: 10,
        minLength: 2,   
        placeholder: 'Начните вводить название города...',
        render: {
            no_results: function (data, escape) {
                
                if (lastQuery && lastQuery.length >= 2) {
                    return '<div class="no-results">Ничего не найдено</div>';
                }
                return ''; 
            }
        }
    });
}
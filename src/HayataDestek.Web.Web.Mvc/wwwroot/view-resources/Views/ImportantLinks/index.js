(function ($) {
    var _importantLinkService = abp.services.app.importantLink,
        l = abp.localization.getSource('Web'),
        _$table = $('#LinkTable');

    var _$importantLinksTable = _$table.DataTable({
        paging: true,
        serverSide: true,
        listAction: {
            ajaxFunction: _importantLinkService.getAll
        },
        buttons: [
            {
                name: 'refresh',
                text: '<i class="fas fa-redo-alt"></i>',
                action: () => _$importantLinksTable.draw(false)
            }
        ],
        responsive: {
            details: {
                type: 'column'
            }
        },
        columnDefs: [
            {
                targets: 0,
                className: 'control',
                defaultContent: '',
            },
            {
                targets: 1,
                data: 'name',
                sortable: false
            },
            {
                targets: 2,
                data: 'link',
                sortable: false,
                render: data => `<a href="${data}">Link</a>`
            }
        ]
    });

})(jQuery);
declare var $: any;

export class Notification {

    show(type: 'info' | 'success' | 'warning' | 'danger',
        htmlMessage: string,
        from: 'top' | 'bottom',
        align: 'left' | 'center' | 'right') {
        $.notify({
            icon: 'pe-7s-attention',
            message: htmlMessage
        }, {
                type: type,
                timer: 1000,
                placement: {
                    from: from,
                    align: align
                }
            });
    }
}

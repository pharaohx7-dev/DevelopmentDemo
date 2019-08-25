import Swal from 'sweetalert2';

export class Alerts {

    static success(titulo?: string, mensaje: string = '') {
        titulo = titulo === '' ? 'Operación completada' : titulo;

        Swal.fire({
            title: titulo,
            text: mensaje,
            type: 'success',
            buttonsStyling: false,
            confirmButtonClass: 'btn btn-success',
            confirmButtonText: 'Okay'
        });
    }

    static warning(titulo?: string, mensaje: string = '') {
        titulo = titulo === '' ? '¡Atención!' : titulo;

        Swal.fire({
            title: titulo,
            text: mensaje,
            type: 'warning',
            buttonsStyling: false,
            confirmButtonClass: 'btn btn-warning',
            confirmButtonText: 'Okay'
        });
    }

    static error(titulo?: string, mensaje: string = '') {
        titulo = titulo === '' ? '¡Error!' : titulo;

        Swal.fire({
            title: titulo,
            text: mensaje,
            type: 'error',
            buttonsStyling: false,
            confirmButtonClass: 'btn btn-danger',
            confirmButtonText: 'Okay'
        });
    }

    static info(titulo?: string, mensaje: string = '') {
        Swal.fire({
            title: titulo,
            text: mensaje,
            type: 'info',
            buttonsStyling: false,
            confirmButtonClass: 'btn btn-info',
            confirmButtonText: 'Okay'
        });
    }

    static question(titulo?: string, mensaje: string = '') {
        titulo = titulo === '' ? '¡Atención!' : titulo;
        return Swal.fire({
            title: titulo,
            text: mensaje,
            type: 'question',
            showCancelButton: true,
            confirmButtonColor: '#3085d6',
            cancelButtonColor: '#d33',
            confirmButtonText: 'Si, deseo continuar!',
            cancelButtonText: 'Cancelar'
        });
    }

    static load(titulo?: string, mensaje = 'Espere un momento por favor...') {
        titulo = titulo === '' ? 'Procesando solicitud' : titulo;
        return Swal.fire({
            title: titulo,
            text: mensaje,
            showConfirmButton: false,
            allowOutsideClick: false,
            onOpen: () => {
                Swal.showLoading();
            }
        });
    }

    static close() {
        return Swal.close();
    }
}

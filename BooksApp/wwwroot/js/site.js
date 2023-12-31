/**
 * Execute a handler after DOMContentLoaded event
 * 
 * @param {Function} handler
 */
function defer(handler) {
    document.addEventListener('DOMContentLoaded', handler);
}

/**
 * Submit a form with given action and method
 * 
 * @param {string} action
 * @param {'get' | 'post'} method
 */
function formSubmit(action, method = 'post') {
    const form = document.createElement('form');
    form.method = method;
    form.action = action;
    document.body.appendChild(form);
    form.submit();
}

const confirmationModalHtml = `
    <div class="modal fade" tabindex="-1" aria-hidden="true">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header">
                    <h5 class="modal-title"></h5>
                    <button type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
                </div>
                <div class="modal-body"></div>
                <div class="modal-footer">
                    <button type="button" class="btn btn-secondary" data-bs-dismiss="modal">Cancel</button>
                    <button type="button" class="btn btn-danger" data-confirm>Confirm</button>
                </div>
            </div>
        </div>
    </div>
`;

/**
 * Show a confirmation modal
 *
 * @param {string} title
 * @param {string} message
 * @returns {Promise<boolean>}
 */
function displayConfirmation(title, message) {
    return new Promise(resolve => {
        const modalWrapper = document.createElement('div');
        document.body.append(modalWrapper);
        modalWrapper.innerHTML = confirmationModalHtml;

        const modalElement = modalWrapper.querySelector('.modal');
        const modalTitleElement = modalWrapper.querySelector('.modal-title');
        const modalBodyElement = modalWrapper.querySelector('.modal-body');
        const modalConfirmButton = modalWrapper.querySelector('[data-confirm]');
        
        modalTitleElement.innerHTML = title;
        modalBodyElement.innerHTML = message;

        const modal = new bootstrap.Modal(modalElement);
        modal.show(undefined);
        
        const dispose = () => {
            modalElement.removeEventListener('hide.bs.modal', handleDisposed);
            modalConfirmButton.removeEventListener('click', handleConfirmed);
            modalWrapper.remove();
        };
        
        const handleDisposed = () => {
            resolve(false);
            dispose();
        };
        
        const handleConfirmed = () => {
            resolve(true);
            dispose();
            modal.hide();
        };

        modalElement.addEventListener('hidden.bs.modal', handleDisposed);
        modalConfirmButton.addEventListener('click', handleConfirmed);
    });
}

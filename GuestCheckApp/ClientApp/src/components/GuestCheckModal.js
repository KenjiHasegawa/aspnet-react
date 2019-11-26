import React, { Component } from 'react';
import Button from 'react-bootstrap/Button'
import Modal from 'react-bootstrap/Modal'
import { FaPlus, FaMinus } from 'react-icons/fa';

export class GuestCheckModal extends Component {
    constructor(props) {
        super(props);
        this.state = {
            loading: true,
            show: false,
            GuestCheck: this.props.GuestCheck,
            Products: this.props.guestCheckProducts,       
            ModalTitle: "New Guest Check"
        }
    }

    handleSubmit() {
        fetch("api/GuestCheck", {
            method: 'POST',
            headers: { 'Content-Type': 'application/json' },
            body: JSON.stringify({
                GuestCheckProduct: this.state.Products,
                GuestCheck: this.state.GuestCheck
            })
        })
            .then(response => response.json())
            .then(data => { return data })
            .catch(err => console.log(err));
    } 

    handleClose = () => {
        this.setState({ show: false });
    }

    handlePlus = () => {

    }

    handleMinus = () => {

    }

    static renderTable() {
        return (
            <table className='table table-striped' aria-labelledby="tableLabel">
                <thead>
                    <tr>
                        <th>Product</th>
                        <th>Price</th>
                        <th>Quantity</th>
                        <th>Controls</th>
                    </tr>
                </thead>
                <tbody>
                    {this.state.Products.map(product =>
                        <tr key={product.ProductID}>
                            <td>{product.ProductName}</td>
                            <td>{product.ProductValue}</td>
                            <td>{product.ProductQty}</td>
                            <td><FaMinus /> <FaPlus /></td>
                        </tr>
                    )}
                </tbody>
            </table>
        )
    }
    render() {
        let content = this.state.loading
            ? <p>Loading ...</p>
            : GuestCheckModal.renderTable();
        return (
            
            <Modal show={this.state.show} aria-labelledby="contained-modal-title-vcenter">
                <Modal.Header closeButton>
                    <Modal.Title id="contained-modal-title-vcenter">
                        ${this.state.ModalTitle}
                    </Modal.Title>
                </Modal.Header>
                <Modal.Body>
                    {content}
                </Modal.Body>
                <Modal.Footer>
                    <Button variant="secondary" onClick={this.handleClose}>Close</Button>
                    <Button variant="primary" onClick={this.handleSubmit}>Save Changes</Button>
                </Modal.Footer>
            </Modal>
        )
    }

}

function GuestCheckAddButton() {
    const [showModal, setShowModal] = React.useState(false);
    const handleShow = () => setShowModal(true);
    return(
        <Button color="primary" onClick={handleShow}>
            <FaPlus color="white" /> Add Guest Check
            <GuestCheckModal show={showModal} />
        </Button >
    )
}

export default GuestCheckAddButton;
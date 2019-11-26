import React, { Component } from 'react';
import GuestCheckAddButton, { GuestCheckModal } from './GuestCheckModal';

export class FetchGuestCheck extends Component {
    constructor(props) {
        super(props);
        this.state = {
            guestChecks: [],
            loading: true,
            showModal: false,
            guestCheck: {},
            guestCheckProducts: {}
        };
    }
    
    componentDidMount() {
        this.populateGuestCheckData();
    };

    handleRowClick = e => {
        const id = e.currentTarget.getAttribute("data-rowid");
        this.populateGuestCheckModal(id);
    };
      

    render() {
        let modalTitle = this.state.GuestCheck
            ? "Guest Check #" + this.state.GuestCheck.GuestCheckID + "<small>Created on: " + this.state.GuestCheck.GuestCheckDateCreated + "</small>"
            : "New Guest Check";

        return (
            <div>
                <h1 id="tableLabel">Guest Check List</h1>
                <GuestCheckAddButton />
                <GuestCheckModal show={this.state.showModal} guestCheck={this.state.guestCheck} guestCheckProducts={this.state.guestCheckProducts} modalTitle={modalTitle} />
                <table className='table table-striped' aria-labelledby="tabelLabel">
                    <thead>
                        <tr>
                            <th>Status</th>
                            <th>Value</th>
                        </tr>
                    </thead>
                    <tbody>
                        {this.state.guestChecks.map(guestCheck =>
                            <tr key={guestCheck.guestCheckID} data-rowid={guestCheck.guestCheckID} onClick={this.handleRowClick}>
                                <td>{guestCheck.guestCheckStatus}</td>
                                <td>{guestCheck.guestCheckValue}</td>
                            </tr>
                        )}
                    </tbody>
                </table>
            </div>
        );
    };

    async populateGuestCheckModal(id) {
        const response = await fetch(`api/GuestCheck/${id}`, {
            method: 'GET',
            headers: {
                'Content-Type': 'application/json',
                'Accept': 'application/json'
            }
        })
        const data = await response.json();
        this.setState({ guestCheck: data.guestCheck });
        this.setState({ guestCheckProducts: data.guestCheckProducts });
        this.setState({ showModal: true });
    };

    async populateGuestCheckData() {
        const response = await fetch('api/GuestCheck', {
            headers: {
                'Content-Type': 'application/json',
                'Accept': 'application/json'
            }
        });
        const data = await response.json();
        this.setState({ guestChecks: data, loading: false });
    };
};

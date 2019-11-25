import React, { Component } from 'react';

export class FetchGuestCheck extends Component {
    static displayName = FetchGuestCheck.name;

    constructor(props) {
        super(props);
        this.state = { guestChecks: [], loading: true };
    }

    componentDidMount() {
        this.populateGuestCheckData();
    }

    static renderGuestCheckTable(guestChecks) {
        return (
            <table className='table table-striped' aria-labelledby="tabelLabel">
                <thead>
                    <tr>
                        <th>Code</th>
                        <th>Status</th>
                        <th>Value</th>
                    </tr>
                </thead>
                <tbody>
                    {guestChecks.map(guestCheck =>
                        <tr key={guestCheck.guestCheckID}>
                            <td>{guestCheck.guestCheckID}</td>
                            <td>{guestCheck.guestCheckStatus}</td>
                            <td>{guestCheck.guestCheckValue}</td>
                        </tr>
                    )}
                </tbody>
            </table>
        );
    }

    render() {
        let contents = this.state.loading
            ? <p><em>Loading...</em></p>
            : FetchGuestCheck.renderGuestCheckTable(this.state.guestChecks);

        return (
            <div>
                <h1 id="tabelLabel" >Guest Check List</h1>
                {contents}
            </div>
        );
    }

    async populateGuestCheckData() {
        const response = await fetch('api/GuestCheck', {
            headers: {
                'Content-Type': 'application/json',
                'Accept': 'application/json'
            }
        });
        const data = await response.json();
        this.setState({ guestChecks: data, loading: false });
    }
}

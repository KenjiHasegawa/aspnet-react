import React, { Component } from 'react';

export class FetchProduct extends Component {
    constructor(props) {
        super(props);
        this.state = { products: [], loading: true };
    }

    componentDidMount() {
        this.populateProductData();
    }

    static renderProductsTable(products) {
        return (
            <table className='table table-striped' aria-labelledby="tabelLabel">
                <thead>
                    <tr>
                        <th>Name</th>
                        <th>Description</th>
                        <th>Type</th>
                        <th>Value</th>
                    </tr>
                </thead>
                <tbody>
                    {products.map(product =>
                        <tr key={product.productID}>
                            <td>{product.productName}</td>
                            <td>{product.productDescription}</td>
                            <td>{product.productType}</td>
                            <td>{product.productValue}</td>
                        </tr>
                    )}
                </tbody>
            </table>
        );
    }

    render() {
        let contents = this.state.loading
            ? <p><em>Loading...</em></p>
            : FetchProduct.renderProductsTable(this.state.products);

        return (
            <div>
                <h1 id="tabelLabel" >Product List</h1>
                {contents}
            </div>
        );
    }

    async populateProductData() {
        const response = await fetch('api/Product', {
            headers: {
                'Content-Type': 'application/json',
                'Accept': 'application/json'
            }
        });
        const data = await response.json();
        this.setState({ products: data, loading: false });
    }
}

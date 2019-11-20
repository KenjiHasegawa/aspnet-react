import * as React from 'react';
import { RouteComponentProps } from 'react-router';
import { Link, NavLink } from 'react-router-dom';
interface FetchProductDataState {
    prodList: ProductData[];
    loading: boolean;
}
export class FetchProduct extends React.Component<RouteComponentProps<{}>, FetchProductDataState> {
    constructor() {
        super();
        this.state = { prodList: [], loading: true };
        fetch('api/Product/Index')
            .then(response => response.json() as Promise<ProductData[]>)
            .then(data => {
                this.setState({ prodList: data, loading: false });
            });
        // This binding is necessary to make "this" work in the callback  
        this.handleDelete = this.handleDelete.bind(this);
    }
    public render() {
        let contents = this.state.loading
            ? <p><em>Loading...</em></p>
            : this.renderEmployeeTable(this.state.prodList);
        return <div>
            <h1>Product Data</h1>
            <p>This component demonstrates fetching Employee data from the server.</p>
            <p>
                <Link to="/addemployee">Create New</Link>
            </p>
            {contents}
        </div>;
    }
    // Handle Delete request for an employee  
    private handleDelete(id: number) {
        if (!confirm("Do you want to delete employee with Id: " + id))
            return;
        else {
            fetch('api/Employee/Delete/' + id, {
                method: 'delete'
            }).then(data => {
                this.setState(
                    {
                        prodList: this.state.prodList.filter((rec) => {
                            return (rec.productId != id);
                        })
                    });
            });
        }
    }
    // Returns the HTML table to the render() method.  
    private renderProductTable(prodList: ProductData[]) {
        return <table className='table'>
            <thead>
                <tr>
                    <th></th>
                    <th>ProductId</th>
                    <th>ProductName</th>
                    <th>ProductValue</th>
                </tr>
            </thead>
            <tbody>
                {prodList.map(prod =>
                    <tr key={prod.ProductId}>
                        <td></td>
                        <td>{prod.ProductId}</td>
                        <td>{prod.ProductName}</td>
                        <td>{prod.ProductValue}</td>
                        <td>
                            <a className="action" onClick={(id) => this.handleEdit(prod.ProductId)}>Edit</a>  |
                            <a className="action" onClick={(id) => this.handleDelete(prod.ProductId)}>Delete</a>
                        </td>
                    </tr>
                )}
            </tbody>
        </table>;
    }
}
export class ProductData {
    productId: number = 0;
    productName: string = "";
    productType: string = "";
    productValue: string = "";
}
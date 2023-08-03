import { OrderState } from "../../reducers/OrderReducer/OrderState";
import { OrderAction } from "../../reducers/OrderReducer/OrderActions";
import OrderTableRow from "../OrderTableRow/OrderTableRow";
import "./orderTable.css";

interface OrderTableProps {
  state: OrderState,
  dispatch: React.Dispatch<OrderAction>
}

export default ({
  state,
  dispatch
}: OrderTableProps) => {
  const columnHeaders = [
    'ID',
    'CustomerId',
    'Product',
    'Quantity',
    'Total'
  ];
  return (
    <div className="org-ordertable">
      { columnHeaders.map((header, index) =>
          <div 
            key={ index }
            className="header"
            children={ <span>{header}</span> } />) }
      { state.orders.map((value, index) =>
          <OrderTableRow
            key={ index }
            id={ value.id }
            customerId={ value.customerId }
            productId={ value.productId }
            quantity={ value.quantity }
            totalCost={ value.totalCost } />) }
    </div>
  );
}
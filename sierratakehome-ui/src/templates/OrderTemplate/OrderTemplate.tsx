import CreateOrderForm from "../../organisms/CreateOrderForm/CreateOrderForm";
import OrderTable from "../../organisms/OrderTable/OrderTable";
import { OrderAction } from "../../reducers/OrderReducer/OrderActions";
import { OrderState } from "../../reducers/OrderReducer/OrderState";
import "./orderTemplate.css";

interface OrderTemplateProps {
  state: OrderState,
  dispatch: React.Dispatch<OrderAction>
}

export default ({
  state,
  dispatch
}: OrderTemplateProps) => {
  return (
    <div className="tp-order">
      <CreateOrderForm
        state={ state }
        dispatch={ dispatch } />
      <OrderTable
        state={ state }
        dispatch={ dispatch } />
    </div>
  );
}
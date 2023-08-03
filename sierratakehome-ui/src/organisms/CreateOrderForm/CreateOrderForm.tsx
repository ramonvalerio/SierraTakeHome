import axios from "axios";
import Cookies from "universal-cookie";
import { OrderAction, OrderActionType } from "../../reducers/OrderReducer/OrderActions";
import { OrderState } from "../../reducers/OrderReducer/OrderState";
import "./createOrderForm.css";

interface CreateOrderFormProps {
  state: OrderState,
  dispatch: React.Dispatch<OrderAction>
}

export default ({
  state,
  dispatch
}: CreateOrderFormProps) => {
  const token = new Cookies().get('TOKEN');
  return (
    <div className="org-createorderform">
      <div className="wrapper">
        <div className="input">
          <label>Client ID:</label>
          <input 
            type="text"
            onChange={ (e) => dispatch({
              type: OrderActionType.UPDATE_ORDER_FORM,
              customerId: e.currentTarget.value,
              productId: state.form.productId,
              quantity: state.form.quantity
            }) } />
        </div>
        <div className="input">
          <label>Product ID:</label>
          <input 
            type="text"
            onChange={ (e) => dispatch({
              type: OrderActionType.UPDATE_ORDER_FORM,
              customerId: state.form.customerId,
              productId: e.currentTarget.value,
              quantity: state.form.quantity
            }) } />
        </div>
        <div className="input">
          <label>Quantity:</label>
          <input 
            type="text"
            onChange={ (e) => dispatch({
              type: OrderActionType.UPDATE_ORDER_FORM,
              customerId: state.form.customerId,
              productId: state.form.productId,
              quantity: e.currentTarget.value
            }) } />
        </div>
        <button 
          children="Submit"
          onClick={ () => {
            dispatch({ type: OrderActionType.ADD_ORDER_IN_PROGRESS });
            axios.post(
              'http://localhost:3500/Order', {
                  customerId: state.form.customerId,
                  productId: state.form.productId,
                  quantity: parseInt(state.form.quantity)
                },{ 
                headers: {
                  "Authorization" : `Bearer ${token}`,
                  "Content-Type": 'application/json'
                }})
              .then(response => {
                dispatch({ 
                  type: OrderActionType.ADD_ORDER_SUCCESS,
                  order: response.data
                });
              })
              .catch(_ => dispatch({ 
                type: OrderActionType.ADD_ORDER_ERROR 
              }));
          }} />
      </div>
    </div>
  );
}
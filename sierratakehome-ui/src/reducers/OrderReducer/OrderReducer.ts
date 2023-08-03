import { OrderAction, OrderActionType } from "./OrderActions";
import { OrderState } from "./OrderState";

export default (previousState: OrderState, action: OrderAction): OrderState => {
  switch (action.type) {
    case OrderActionType.UPDATE_ORDER_FORM:
      return {
        ...previousState,
        form: {
          customerId: action.customerId,
          productId: action.productId,
          quantity: action.quantity.replace(/[^0-9]/, '')
        }
      };

    case OrderActionType.ADD_ORDER_IN_PROGRESS:
      return previousState;

    case OrderActionType.ADD_ORDER_SUCCESS:
      return {
        ...previousState,
        orders: [
          ...previousState.orders,
          action.order
        ]
      };

    case OrderActionType.ADD_ORDER_ERROR:
      return previousState;
    
    case OrderActionType.LOAD_ORDERS_IN_PROGRESS:
      return previousState;

    case OrderActionType.LOAD_ORDERS_SUCCESS:
      return {
        ...previousState,
        orders: action.orders
      };

    case OrderActionType.LOAD_ORDERS_ERROR:
      return previousState;
  }
}
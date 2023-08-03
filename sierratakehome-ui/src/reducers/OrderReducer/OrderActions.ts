import { Order } from "./OrderState";

export enum OrderActionType {
  LOAD_ORDERS_IN_PROGRESS,
  LOAD_ORDERS_SUCCESS,
  LOAD_ORDERS_ERROR,
  ADD_ORDER_IN_PROGRESS,
  ADD_ORDER_SUCCESS,
  ADD_ORDER_ERROR,
  UPDATE_ORDER_FORM
};

export type OrderAction = {
  type: OrderActionType.UPDATE_ORDER_FORM,
  customerId: string,
  productId: string,
  quantity: string,
} | {
  type: OrderActionType.ADD_ORDER_IN_PROGRESS,
} | {
  type: OrderActionType.ADD_ORDER_SUCCESS,
  order: Order
} | {
  type: OrderActionType.ADD_ORDER_ERROR,
} | {
  type: OrderActionType.LOAD_ORDERS_IN_PROGRESS,
} | {
  type: OrderActionType.LOAD_ORDERS_SUCCESS,
  orders: Order[]
} | {
  type: OrderActionType.LOAD_ORDERS_ERROR,
};
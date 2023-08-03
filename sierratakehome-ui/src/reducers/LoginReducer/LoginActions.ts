export enum LoginActionType {
  UPDATE_LOGIN_FORM,
  LOGIN_IN_PROGRESS,
  LOGIN_SUCCESS,
  LOGIN_ERROR
};

export type LoginAction = {
  type: LoginActionType.UPDATE_LOGIN_FORM,
  username: string,
  password: string
} | {
  type: LoginActionType.LOGIN_IN_PROGRESS,
} | {
  type: LoginActionType.LOGIN_SUCCESS,
} | {
  type: LoginActionType.LOGIN_ERROR,
};
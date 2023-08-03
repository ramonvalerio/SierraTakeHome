export enum RegisterActionType {
  UPDATE_REGISTER_FORM,
  REGISTER_IN_PROGRESS,
  REGISTER_SUCCESS,
  REGISTER_ERROR
};

export type RegisterAction = {
  type: RegisterActionType.UPDATE_REGISTER_FORM,
  username: string,
  password: string,
} | {
  type: RegisterActionType.REGISTER_IN_PROGRESS,
} | {
  type: RegisterActionType.REGISTER_SUCCESS,
} | {
  type: RegisterActionType.REGISTER_ERROR,
};
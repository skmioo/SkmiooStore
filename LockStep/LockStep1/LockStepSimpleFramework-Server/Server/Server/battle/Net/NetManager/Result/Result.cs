using System;
/**
 * 错误码
 * Description: <br>
 * Create DateTime: 2015年3月25日 下午3:04:11 
 * @author chiwenyang
 *
 */
public class Result {
	public static int OK = 0; // 成功
	
	// 1 ~ 999 通用错误码
	public static int FAULT = 1; // 失败，尽量少用这个，采用更明确的错误码标识
	
	// 1000 ~ 1999 GM 占用
	public static int GM_NOT_REGISTERED = 1000; // gm命令未注册，没有注册处理对象
	public static int GM_PARAM_COUNT_NOT_VALID = 1001; // gm参数个数无效
	public static int GM_PARAM_TYPE_NOT_VALID = 1002; // gm参数类型无效
	
	//public static final int GM_GOTO
	
	// 2000 ~ 3999 Item, Bag, Drop 占用
	public static int DROPBOX_NOT_EXIST = 2000;
	public static int DROPBOX_LOCKED_BY_OTHERS = 2001;
	public static int PICKUP_FAILED_BAG_IS_FULL= 2002;
	public static int PICKUP_FAILED_ADD_TO_BAG_FAILED_REASON_UNKOWN = 2003; // 
	
}

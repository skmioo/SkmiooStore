using System.Text;

public class NetMessageBase //: I_OnUpdate, I_OnStop, I_OnDestroy
{
	protected object[] msgParams = null;
	protected readonly bool isSendNetMessage = true;

	private bool bFree = true;

	#region  public virtual Function


	public virtual void SetMessageParams(params object[] msgParams) { this.msgParams = msgParams; }

	public virtual void OnUpdate() { }

	public virtual void OnStop() { }

	public virtual void OnDestroy() { }
	#endregion

	#region  public  Function
	public bool isFree
	{
		get { return bFree; }
		set { bFree = value; }
	}

	public int GetParamsLength()
	{
		if (msgParams == null)
			return 0;

		return msgParams.Length;
	}

	public T GetParam<T>(int index)
	{
		object param = null;

		if (GetParamsLength() > index && index >= 0)
		{
			param = msgParams[index];
		}

		return (T)param;
	}

	public bool CheckParamsValid(int length)
	{
		if (msgParams == null || msgParams.Length <= 0)
			return false;

		if (msgParams.Length == length)
			return true;

		return false;
	}

    protected string ChangeStr(string str)
    {
        return Utf8ToDefault(DefaultToUtf8(str));
    }

    private string DefaultToUtf8(string str)
    {
        byte[] temp = Encoding.UTF8.GetBytes(str);
        byte[] temp1 = Encoding.Convert(Encoding.Default, Encoding.UTF8, temp);
        string result = Encoding.UTF8.GetString(temp1);
        return result;
    }

    private string Utf8ToDefault(string str)
    {
        byte[] temp = Encoding.Default.GetBytes(str);
        byte[] temp1 = Encoding.Convert(Encoding.UTF8, Encoding.Default, temp);
        string result = Encoding.Default.GetString(temp1);
        return result;
    }

	#endregion
}

# ActiveSupport

A .Net library that makes your code beautiful, explicit and simple. Goal of a project - increase readability of code.

Inspired by python [philosophy](https://www.python.org/dev/peps/pep-0020/) and ActiveSupport library (Ruby on Rails).

```c#
  using ActiveSupport;
```

## DateTime

ActiveSupport extends [DateTime](http://msdn.microsoft.com/en-us/library/system.datetime.aspx) and [DateTimeOffset](http://msdn.microsoft.com/en-us/library/system.datetimeoffset.aspx) to allow you to write as below and more:

```c#
  var june18 = new DateTime(2011,6,18);
		
  june18.Tomorrow(); // 2011/06/19
	
  june18.Yesterday(); // 2011/06/17
	
  june18.Nextyear(); // 2012/06/18
	
  june18.EndOfDay(); // 2011/06/18 23:59:59
	
  june18.BeginnerOfMonth(); // 2011/06/01
	
  june18.EndOfMonth(); // 2011/06/30 23:59:59
	
  june18.BeginningOfWeek(); // 2011/06/12
	
  june18.NextWeek(DayOfWeek.Friday); // 2011/06/24
	
  june18.BeginningOfQuarter(); // 2011/04/01
	
  june18.IsToday(); // true if today is june 18 2011 regardless of time
	
  june18.Change(years: 2010); // 2010/06/18
```

Readable conversation [Integer](http://msdn.microsoft.com/en-us/library/system.int32.aspx) to [TimeSpan](http://msdn.microsoft.com/en-us/library/system.timespan.aspx)

```c#
  1.Hour(); // Timespan of 1 hour
  30.Minutes().Ago(); // 30 minutes ago 
  (2.Hours() + 20.Minutes()).FromNow();  // 2 hours and 20 minutes from now
	
  10.Hours().Since(new DateTime(2011,6,18)); // 2011/06/18 10:00:00
```

## Numbers

ActiveSupport also extends [Integer](http://msdn.microsoft.com/en-us/library/system.int32.aspx) to enable to write as:

```c#
  2.IsEven(); // true
  1.IsEven(); // false
  0.IsOdd(); // false
	
  15.IsMultipleOf(3); // true
	
  1.Byte(); // 1
  1.Kilobyte(); // 1024
  2.Megabytes(); // 2*1024*1024
	
  // looping 10 times
  10.Times(() => {
    // do something which will be executed for 10 times.
  });
```

## String

```c#
  string doubleSpacesString = "    Lorem   ipsum dolor    sit amet, consectetur adipiscing elit, ";
  doubleSpacesString.Squish(); //"Lorem ipsum dolor sit amet, consectetur adipiscing elit,"
  
  "".IsPresent() // false - works like string.IsNullOrWhiteSpace
  "  ".IsPresent() // false
  (null as string).IsPresent() // false
  "test".IsPresent() // true
  
  "34".ToInt32() // 34 as Int32
  "4a".ToInt32() // throws exception
  "4a".AsInt32() // null as Int32?
  "34".AsInt32() // 34 as Int32?
    
  var password = "awesomeSecretPassword";
  var salt = "123jfe3EJV24098EC";
  
  // hash password, so that no one can retrieve password
  var digestPassword = password.ToHashString(salt);
  
  var importantText = "this is super important text, so it need to be encrypt.";
  var secretKey = "thisIsSecretKey";
  
  // encrypt text so that other cannot read but I have key, so I can decrypt back to original one
  var encryptedText = importantText.Encrypt(secretKey);
  
  // decrypt to original
  var decryptedText = encryptedText.Decrypt(secertKey); // decryptedText == importantText
```

## IEnumerable ICollection

Active support methods ```blank?``` and ```present?```  that makes you code more readable

```c#
  if(bid.Transactions != null && bid.Transactions.Count > 0)
  // vs
  if(bid.Transactions.IsPresent())

  //dates - e.g. book.createdAt is "DateTime?"
  if(bid.CreatedAt != null && bid.CreatedAt != default(DateTime))
  // vs
  if(bid.CreatedAt.IsPresent())
```

IsPresent() - means that your varialble has some value, e.g. list has minimum 1 element and list is not null

IsBlank() - !IsPresent() - returns true if IEnumerable is null or has no element

IsEmpty() - works like IsBlank(), but throws exception on null IEnumerable pointer

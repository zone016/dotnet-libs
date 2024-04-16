// Copyright (c) Zone016 Hackerspace. All Rights Reserved. Licensed under the MIT license.

namespace Zone016.Cookie.Server.Interfaces;

public interface IOptionBuilder<T>
{
    Option<T> Build();
}
